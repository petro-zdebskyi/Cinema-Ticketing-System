using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Cinema.Entities;
using Cinema.Repositories;
using System.Configuration;

namespace Cinema_Ticketing_System
{
    public partial class BuyTicketForm : Form
    {
        private readonly string _connectionString;
        private readonly int _showtimeId;
        private int _seatId;
        private List<Seat> _freeSeats;
        private List<Customer> _customers;

        private readonly SqlCustomerRepository customerRepository;
        private readonly SqlSeatRepository seatRepository;
        private readonly SqlSalesRepository salesRepository;
        

        public BuyTicketForm(int showtimeId, string filmName)
        {
            _connectionString = ConfigurationManager.ConnectionStrings["CinemaTicketingSystem_ConnectionString"].ConnectionString;
            _showtimeId = showtimeId;
            seatRepository = new SqlSeatRepository(_connectionString);
            customerRepository = new SqlCustomerRepository(_connectionString);
            salesRepository = new SqlSalesRepository(_connectionString);
            InitializeComponent();
            filmNameLabel.Text = filmName;
        }

        // Event handlers

        private void BuyTicketForm_Load(object sender, EventArgs e)
        {
            GetFreeSeats();
        }

        private void personalSaleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(personalSaleRadioButton.Checked == true)
            {
                firstNameTextBox.Enabled = true;
                lastNameTextBox.Enabled = true;
                cardNumberTextBox.Enabled = true;
                priceLabel.Text = "Discounted price";
            }
        }
        
        private void impersonalSaleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            firstNameTextBox.Enabled = false;
            lastNameTextBox.Enabled = false;
            cardNumberTextBox.Enabled = false;
            priceLabel.Text = "Price";
            ClearForm();
        }

        private void buyTicketButton_Click(object sender, EventArgs e)
        {
            if (impersonalSaleRadioButton.Checked == true)
            {
                if (_seatId < 0)
                {
                    MessageBox.Show("Please, choose seat", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int transactionId = salesRepository.BuyTicketImpersonal(_showtimeId, _seatId);
                string purchaseResult = string.Format("Ticket has been succesfully purchased! Transaction ID = {0}", transactionId);
                MessageBox.Show(purchaseResult, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                GetFreeSeats();
            }

            if (personalSaleRadioButton.Checked == true)
            {
                if (_seatId < 0 || _customers.Count == 0)
                {
                    MessageBox.Show("Please, choose seat and customer", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int transactionId = salesRepository.BuyTicketByCustomer(_showtimeId, _seatId, _customers[0].Id);
                string purchaseResult = string.Format("Ticket has been succesfully purchased! Transaction ID = {0}", transactionId);
                MessageBox.Show(purchaseResult, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                GetFreeSeats();
            }
        }

        private void showCustomerButton_Click(object sender, EventArgs e)
        {
             _customers = (List<Customer>)customerRepository.SelectByName(firstNameTextBox.Text, lastNameTextBox.Text, Convert.ToInt32(cardNumberTextBox.Text));
            
            if (_customers.Count > 0)
            {
                if (_seatId == -1)
                {
                    MessageBox.Show("Please, specity seat to calculate price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                customerFirstNameLabel.Text = _customers[0].FirstName;
                customerLastNameLabel.Text = _customers[0].LastName;
                customerCardNumberLabel.Text = Convert.ToString(_customers[0].CardNumber);
                customerDiscountLabel.Text = Convert.ToString(_customers[0].Discount);
                customerTicketsPurchasedLabel.Text = Convert.ToString(_customers[0].TicketsPurchased);
                customerPriceLabel.Text = Convert.ToString(salesRepository.GetDiscountedPrice(_showtimeId, _seatId, _customers[0].Id));
            }
            else
            {
                customerFirstNameLabel.Text = "";
                customerLastNameLabel.Text = "";
                customerCardNumberLabel.Text = "No match";
                customerDiscountLabel.Text = "";
                customerTicketsPurchasedLabel.Text = "";
            }
        }

        private void sectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rows = _freeSeats.Where(r => r.Section == (int)sectionBox.SelectedItem).GroupBy(x => x.Row).Select(y => y.First()).Distinct().ToArray();
            rowBox.Items.Clear();
            foreach (var item in rows)
            {
                rowBox.Items.Add(item.Row);
            }
        }

        private void rowBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var seats = _freeSeats.Where(r =>  r.Section == (int)sectionBox.SelectedItem && r.Row == (string)rowBox.SelectedItem).ToArray();
            seatBox.Items.Clear();
            foreach (var item in seats)
            {
                seatBox.Items.Add(item.SeatNumber);
            }
        }

        private void seatBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var seat = _freeSeats.Where(x => x.Section == (int)sectionBox.SelectedItem && x.Row == (string)rowBox.SelectedItem && x.SeatNumber == (int)seatBox.SelectedItem).ToArray();
            _seatId = seat[0].Id;
            if(impersonalSaleRadioButton.Checked == true)
            {
                priceLabel.Text = Convert.ToString(salesRepository.GetPrice(_showtimeId, _seatId));
            }
        }

        // Helper functions

        private void GetFreeSeats()
        {
            _freeSeats = (List<Seat>)seatRepository.GetFreeSeats(_showtimeId);
            var sections = _freeSeats.GroupBy(x => x.Section).Select(y => y.First()).Distinct().ToArray();
            sectionBox.Items.Clear();
            sectionBox.ResetText();
            rowBox.Items.Clear();
            rowBox.ResetText();
            seatBox.Items.Clear();
            seatBox.ResetText();
            _seatId = -1;
            foreach (var item in sections)
            {
                sectionBox.Items.Add(item.Section);
            }
        }
        private void ClearForm()
        {
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            cardNumberTextBox.Text = "";
            customerCardNumberLabel.Text = "";
            customerFirstNameLabel.Text = "";
            customerLastNameLabel.Text = "";
            customerDiscountLabel.Text = "";
            customerTicketsPurchasedLabel.Text = "";
            customerPriceLabel.Text = "";
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            int result = customerRepository.AddCustomer(firstNameTextBox.Text, lastNameTextBox.Text, Convert.ToInt32(cardNumberTextBox.Text));

            if (result != 0)
            {
                MessageBox.Show("Customer with that card number already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                MessageBox.Show("Customer successfully added to the database!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}

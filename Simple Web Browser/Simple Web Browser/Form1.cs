﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Simple_Web_Browser
{
    public partial class Form1 : Form
    {

        Manager manager;

        public Form1()
        {
            InitializeComponent();
            manager = new Manager();
            manager.RequestComplete += m_RequestComplete;
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(this);
            frm.Show();
        }

        private async void backPageButton_Click(object sender, EventArgs e)
        {

            manager.getWebsite(manager.historyManager.getPreviousPage(), false);
            manager.RequestComplete += m_RequestComplete;

            // resultDisplay.Text = await manager.getWebsite(manager.historyManager.getPreviousPage(), true);
            //inputBox.Text = manager.currentURL;
            //titleHolder.Text = manager.title;
            // HTTPHolder.Text = manager.request;

            /*
            if (manager.historyManager.CanStepBack == false)
            {
                backPageButton.Enabled = false;
            }
            if (manager.historyManager.CanStepForward == true)
            {
                forwardPageButton.Enabled = true;
            }
            */
        }

        private async void forwardPageButton_Click(object sender, EventArgs e)
        {
            // resultDisplay.Text = await manager.getWebsite(manager.historyManager.getNextPage(), true);
            //inputBox.Text = manager.currentURL;
            //titleHolder.Text = manager.title;
            //HTTPHolder.Text = manager.request;

            manager.getWebsite(manager.historyManager.getNextPage(), false);
            manager.RequestComplete += m_RequestComplete;

            /*

            if (manager.historyManager.CanStepForward == false)
            {
                forwardPageButton.Enabled = false;
            }
            if (manager.historyManager.CanStepBack == true)
            {
                backPageButton.Enabled = true;
            }
            */
        }
        void resultDisplay_TextChanged(object sender, EventArgs e)
        {

        }
        private async void searchButton_Click(object sender, EventArgs e)
        {

            try
            {

                manager.getWebsite(inputBox.Text, false);
                manager.RequestComplete += m_RequestComplete;

                // resultDisplay.Text = await manager.getWebsite(inputBox.Text, false);
                //titleHolder.Text = manager.title;
                //HTTPHolder.Text = manager.request;

                // manager.PageUpdate += m_PageUpdate;
                //manager.RequestComplete += m_RequestComplete;

                // you have no searched something so can go backwords at least once
                /*
                if (manager.historyManager.addedURL)
                {
                    backPageButton.Enabled = true;
                }

                */

            }
            catch (Exception exp) { 
            
                resultDisplay.Text = exp.Message;
            }

            
        }

        void m_RequestComplete(object sender, RequestCompleteArgs e)
        {
            Console.WriteLine(e.pageData);
            Console.WriteLine(e.request);
            Console.WriteLine(e.title);

            resultDisplay.Text = e.pageData;
            inputBox.Text = e.URL;
            titleHolder.Text = e.title;
            HTTPHolder.Text = e.request;

        }


        private async void refreshPageButon_Click(object sender, EventArgs e)
        {
            // resultDisplay.Text = await manager.getWebsite(manager.currentURL, true);
            // refreshPageButon.Click += new EventHandler(NameButtonClicked);
        }
        /*
        private void NameButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("We fired off an event!");
        }

        */

        private async void Form1_Load(object sender, EventArgs e)
        {

            manager.getWebsite(manager.currentURL, false);
            



            //inputBox.Text = manager.currentURL;
            //titleHolder.Text = manager.title;
            //HTTPHolder.Text = manager.request;

            /*
            // When the form loads you can't step forwards or backwords (haven't gone anywhere)
            backPageButton.Enabled = false;
            forwardPageButton.Enabled = false;
          
            */
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }



    }
}

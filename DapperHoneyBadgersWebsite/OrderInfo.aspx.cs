﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DapperHoneyBadgersWebsite
{
    #region Temporary Classes for Testing, delete later
    class TempOrder
    {
        string ID;
        string DATE;
        string ADDRESS;
        string PRICE;

        public TempOrder(int id)
        {
            ID = id.ToString();
            DATE = id.ToString() + "/1/2001";
            ADDRESS = id.ToString() + "99 9th Street";
            PRICE = (id * 100).ToString();
        }

        // Does not necessarily need to be done in the order class itself, but having it here simplies the process.
        public void AppendToRow(HtmlTableRow row )
        {
            // ID, to be clicked. Redirect to the OrderItems page with the id set.
            HtmlTableCell cell = new HtmlTableCell();
            Button btn = new Button();
            btn.ID = ID;
            btn.Text = ID;
            btn.BackColor = System.Drawing.Color.Transparent;
            btn.Click += new EventHandler( delegate ( object s, EventArgs e )
            {
                HttpContext.Current.Session.Add( "OrderID", (s as Button).ID );
                HttpContext.Current.Response.Redirect( "OrderInfo.aspx" );
            } );
            cell.Controls.Add( btn );
            row.Cells.Add( cell );

            // Date, Address, and Price simply need to be displayed.
            cell = new HtmlTableCell();
            cell.InnerHtml = DATE;
            row.Cells.Add( cell );

            cell = new HtmlTableCell();
            cell.InnerHtml = ADDRESS;
            row.Cells.Add( cell );

            cell = new HtmlTableCell();
            cell.InnerHtml = PRICE;
            row.Cells.Add( cell );
        }
    }

    class TempItem
    {
        public string ID;
        public string CategoryID;
        public double PricePerUnit;
        public int Qty;
        public double TotalPrice { get { return PricePerUnit * Qty; } }

        public TempItem( int ID )
        {
            this.ID = ID.ToString();
            CategoryID = this.ID.ToString();
            this.PricePerUnit = 1.01 * ID;
            this.Qty = ID;
        }

        // Does not necessarily need to be done in the item class itself, but having it here simplies the process.
        public void AppendToRow( HtmlTableRow row )
        {
            // ID, to be clicked. Redirect to the OrderItems page with the id set.
            HtmlTableCell cell = new HtmlTableCell();
            Button btn = new Button();
            btn.ID = ID;
            btn.Text = ID;
            btn.BackColor = System.Drawing.Color.Transparent;
            btn.Click += new EventHandler( delegate ( object s, EventArgs e )
            {
                HttpContext.Current.Session.Add( "ProductID", (s as Button).ID );
                HttpContext.Current.Response.Redirect( "OrderInfo.aspx" );
            } );
            cell.Controls.Add( btn );
            row.Cells.Add( cell );

            // Date, Address, and Price simply need to be displayed.
            cell = new HtmlTableCell();
            cell.InnerHtml = DATE;
            row.Cells.Add( cell );

            cell = new HtmlTableCell();
            cell.InnerHtml = ADDRESS;
            row.Cells.Add( cell );

            cell = new HtmlTableCell();
            cell.InnerHtml = PRICE;
            row.Cells.Add( cell );
        }
    }

    #endregion

    public partial class OrderInfo : System.Web.UI.Page
    {
        // Add our basic heading information.
        private void PrepareOrderHeading(HtmlTableRow heading )
        {
            // ID
            HtmlTableCell cell = new HtmlTableCell();
            cell.Style.Add( "font-weight", "bold" );
            cell.InnerHtml = "ID";
            heading.Cells.Add( cell );

            // Date
            cell = new HtmlTableCell();
            cell.Style.Add( "font-weight", "bold" );
            cell.InnerHtml = "Date";
            heading.Cells.Add( cell );

            // Address
            cell = new HtmlTableCell();
            cell.Style.Add( "font-weight", "bold" );
            cell.InnerHtml = "Address";
            heading.Cells.Add( cell );

            // Price
            cell = new HtmlTableCell();
            cell.Style.Add( "font-weight", "bold" );
            cell.InnerHtml = "Price";
            heading.Cells.Add( cell );
        }
        private void PrepareItemHeading( HtmlTableRow heading )
        {
            // ID
            HtmlTableCell cell = new HtmlTableCell();
            cell.Style.Add( "font-weight", "bold" );
            cell.InnerHtml = "ID";
            heading.Cells.Add( cell );

            // Date
            cell = new HtmlTableCell();
            cell.Style.Add( "font-weight", "bold" );
            cell.InnerHtml = "Date";
            heading.Cells.Add( cell );

            // Address
            cell = new HtmlTableCell();
            cell.Style.Add( "font-weight", "bold" );
            cell.InnerHtml = "Address";
            heading.Cells.Add( cell );

            // Price
            cell = new HtmlTableCell();
            cell.Style.Add( "font-weight", "bold" );
            cell.InnerHtml = "Price";
            heading.Cells.Add( cell );
        }

        // Add in information related to an order.

        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear any existing information.
            orderTable.Controls.Clear();

            // If we do not have a specific order specified, display all orders.
            if ( HttpContext.Current.Session["OrderID"] == null )
            {
                // Prepare and add our heading row.
                HtmlTableRow heading = new HtmlTableRow();
                PrepareHeading( heading );
                orderTable.Controls.Add( heading );

                // Prepare our rows (hardcoded example for now.)
                for ( int x = 0; x < 8; x++ )
                {
                    TempOrder order = new TempOrder( x );
                    HtmlTableRow orderRow = new HtmlTableRow();
                    order.AppendToRow( orderRow );
                    orderTable.Controls.Add( orderRow );
                }
            }
            // If we DO have a specific order specified, display its items instead.
            else
            {
                // Prepare and add our heading row.
                HtmlTableRow heading = new HtmlTableRow();
                PrepareHeading( heading );
                orderTable.Controls.Add( heading );

                // Prepare our rows (hardcoded example for now.)
                for ( int x = 0; x < 8; x++ )
                {
                    TempOrder order = new TempOrder( x );
                    HtmlTableRow orderRow = new HtmlTableRow();
                    order.AppendToRow( orderRow );
                    orderTable.Controls.Add( orderRow );
                }
            }
        }
    }
}
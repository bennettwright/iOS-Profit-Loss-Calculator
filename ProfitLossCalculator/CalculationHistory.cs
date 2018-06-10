using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace ProfitLossCalculator
{
    public partial class CalculationHistory : UITableViewController
    {
        public CalculationHistory (IntPtr handle) : base (handle)
        {
        }

        private List<TableItem> coreData =  new List<TableItem>();
        private static List<TableItem> data = new List<TableItem>();

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            HistoryTable.Source = new TableSource(coreData, this);
        }

        //info1 will be all entered info, like entry, exit, etc.
        //info2 will be all the generated info like profit, percentage, etc.
        public static void AddData(string title, string subtitle) => data.Add(new TableItem(title, subtitle));

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            coreData.AddRange(data);
            HistoryTable.ReloadData();
            data.Clear(); // make sure to clear so it doesn't add same calculation next time
        }
    }

    /* Class taken from xamarin example: 
     * https://docs.microsoft.com/en-us/xamarin/ios/user-interface/controls/tables/populating-a-table-with-data
     */
    public class TableSource : UITableViewSource
    {

        List<TableItem> tableItems;
        protected string cellIdentifier = "TableCell";
        UITableViewController owner;

        public TableSource(List<TableItem> items, UITableViewController owner)
        {
            tableItems = items;
            this.owner = owner;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableItems.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // request a recycled cell to save memory  
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);


            var cellStyle = UITableViewCellStyle.Subtitle;

            // if there are no cells to reuse, create a new one  
            if (cell == null)
            {
                cell = new UITableViewCell(cellStyle, cellIdentifier);
            }

            cell.TextLabel.Text = tableItems[indexPath.Row].Title;
            cell.DetailTextLabel.Text = tableItems[indexPath.Row].Details;
            return cell;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }


        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            UIAlertController okAlertController = UIAlertController.Create(tableItems[indexPath.Row].Title, tableItems[indexPath.Row].Details, UIAlertControllerStyle.Alert);
            okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            owner.PresentViewController(okAlertController, true, null);
            tableView.DeselectRow(indexPath, true);
        }

        #region  editing methods 

        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
        {
            switch (editingStyle)
            {
                case UITableViewCellEditingStyle.Insert:
                    tableItems.Insert(indexPath.Row, new TableItem("(inserted)"));
                    tableView.InsertRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
                    break;

                case UITableViewCellEditingStyle.None:
                    Console.WriteLine("CommitEditingStyle:None called");
                    break;
            }
        }

        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return false;
        }


        public void WillBeginTableEditing(UITableView tableView)
        {
            tableView.BeginUpdates();

            tableView.InsertRows(new NSIndexPath[] {
                    NSIndexPath.FromRowSection (tableView.NumberOfRowsInSection (0), 0)
                }, UITableViewRowAnimation.Fade);
            tableItems.Add(new TableItem("(add new)"));

            tableView.EndUpdates();
        }

        #endregion
    }

    public class TableItem
    {
        public string Title { get; set; }

        public string Details { get; set; }

        public UITableViewCellStyle CellStyle
        {
            get { return cellStyle; }
            set { cellStyle = value; }
        }
        protected UITableViewCellStyle cellStyle = UITableViewCellStyle.Default;

        public UITableViewCellAccessory CellAccessory
        {
            get { return cellAccessory; }
            set { cellAccessory = value; }
        }
        protected UITableViewCellAccessory cellAccessory = UITableViewCellAccessory.None;

        public TableItem() { }

        public TableItem(string title)
        { Title = title; }

        public TableItem(string title, string detail)
        { Title = title; Details = detail; }

    } 
}
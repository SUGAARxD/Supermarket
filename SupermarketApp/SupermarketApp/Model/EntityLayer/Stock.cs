namespace SupermarketApp.Model.EntityLayer
{
    internal class Stock
    {

        #region Properties and members

        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public string SupplyDate { get; set; }
        public string ExpirationDate { get; set; }
        public float PurchasePrice { get; set; }
        public float SalePrice { get; set; }
        public float VAT { get; set; }
        public Product Product { get; set; }

        #endregion

    }
}

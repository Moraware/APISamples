// Get all POs
var pos = conn.GetPurchaseOrders(new PurchaseOrderFilter(), new PagingOptions(0, 99999));
// Loop through them
foreach (var po in pos)
{
    // Do something with each PO
    Console.WriteLine("PO: {0}", po.PurchaseOrderNumber);

    // NOTE: If you want a PO total, you have to add up the lines yourself
    decimal totalCost = new decimal();

    // Get all the PO Lines (PO Receipts are different!)
    var pols = conn.GetPurchaseOrderLines(po.PurchaseOrderId);
    // Loop through them
    foreach (var pol in pols)
    {
        // do something with each PurchaseOrderLine
        // NOTE: Usually, you'll first determine whether it's a Miscellaneous or a Product line 
        // and cast appropriately
        if (pol.PurchaseOrderLineType == PurchaseOrderLine.PurchaseOrderLineType_Enum.Product) 
        {
            var prodLine = (PurchaseOrderProductLine)pol;
            Console.WriteLine("   Line Qty: {0}, Line description: {1}, Line pre-tax amount: {2}", 
                prodLine.OrderedQuantity, prodLine.LineDescription, prodLine.TotalCost);
            totalCost += prodLine.TotalCost;
        }
        else
        {
            var miscLine = (PurchaseOrderMiscellaneousLine)pol;
            Console.WriteLine("   Line Qty: {0}, Line description: {1}, Line pre-tax amount: {2}",
                miscLine.OrderedQuantity, miscLine.LineDescription, miscLine.TotalCost);
            totalCost += miscLine.TotalCost;
        }
    }
    Console.WriteLine("PO: {0}, total = {1}", po.PurchaseOrderNumber, totalCost);
}

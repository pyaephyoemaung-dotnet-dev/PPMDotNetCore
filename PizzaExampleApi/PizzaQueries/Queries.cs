namespace PizzaExampleApi.PizzaQueries
{
    public class Queries
    {
        public static string PizzaOrderQuery { get; } = 
            @"SELECT po.*,p.PizzaName,p.PizzaPrice FROM [dbo].[tbl_PizzaOrder] po
            inner join tbl_Pizza p on p.PizzaId = po.PizzaId
            where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo;";
        public static string PizzaOrderDetailQuery { get; } =
            @"SELECT pod.*,pe.PizzaExtraName,pe.PizzaPrice FROM [dbo].[tbl_PizzaDetail] pod
            inner join tbl_PizzaExtra pe on pe.PizzaExtraId = pod.PizzaExtraId
            where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo;";
    }
}

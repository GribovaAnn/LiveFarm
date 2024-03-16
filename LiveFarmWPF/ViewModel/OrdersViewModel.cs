using LiveFarmWPF.Model;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace LiveFarmWPF.ViewModel
{
    public class OrdersViewModel
    {
        public static void MakingPdf(int idOrder)
        {
            Core db = new Core();
            Word.Application application = new Word.Application();
            Word.Document document = new Word.Document();

            Word.Paragraph titleParagraph = document.Paragraphs.Add();
            Word.Range titleRange = titleParagraph.Range;
            titleRange.Text = "ТАЛОН ЗАКАЗА";
            titleRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            titleRange.Bold = 1;
            titleRange.InsertParagraphAfter();
            //номер + дата
            Word.Paragraph numberOrderParagraph = document.Paragraphs.Add();
            Word.Range numberOrderRange = numberOrderParagraph.Range;
            numberOrderRange.Text = $"{db.context.Orders.FirstOrDefault(x => x.IdOrder == idOrder).NumberOfOrder}\n{db.context.Orders.FirstOrDefault(x => x.IdOrder == idOrder).DateMaking}";
            numberOrderRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            numberOrderRange.InsertParagraphAfter();

            Word.Paragraph contentTitleParagraph = document.Paragraphs.Add();
            Word.Range contentTitleRange = contentTitleParagraph.Range;
            contentTitleRange.Text = "Состав заказа:";
            contentTitleRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            contentTitleRange.InsertParagraphAfter();
            //состав заказа
            Word.Paragraph contentOrderParagraph = document.Paragraphs.Add();
            Word.Range contentOrderRange = contentOrderParagraph.Range;
            Word.Table contentOrderTable = document.Tables.Add(contentOrderRange, db.context.ProductsInOrder.Where(x => x.OrderId == idOrder).Count() + 1, 2);
            Word.Range cellContentOrder;
            cellContentOrder = contentOrderTable.Cell(1, 1).Range;
            cellContentOrder.Text = "Название";
            cellContentOrder = contentOrderTable.Cell(1, 2).Range;
            cellContentOrder.Text = "Кол-во, шт";
            contentOrderTable.Rows[1].Range.Bold = 1;
            contentOrderTable.Columns[1].Width = 400;
            contentOrderTable.Columns[2].Width = 70;
            int i = 1;
            foreach (var item in db.context.ProductsInOrder.Where(x => x.OrderId == idOrder))
            {
                cellContentOrder = contentOrderTable.Cell(i + 1, 1).Range;
                cellContentOrder.Text = db.context.Assortment.FirstOrDefault(x => x.IdProduct == item.ProductId).Title;
                cellContentOrder = contentOrderTable.Cell(i + 1, 2).Range;
                cellContentOrder.Text = item.Quantity.ToString();
                i++;
            }
            //сумма
            double summ = 0;
            foreach (var item in db.context.ProductsInOrder.Where(x => x.OrderId == idOrder))
            {
                summ += db.context.Assortment.FirstOrDefault(x => x.IdProduct == item.ProductId).FinalPrice * item.Quantity;
            }
            if (summ > 2000) summ -= summ * 0.05;
            Word.Paragraph priceOrderParagraph = document.Paragraphs.Add();
            Word.Range priceOrderRange = priceOrderParagraph.Range;
            priceOrderRange.Text = $"Сумма заказа: {summ}₽";
            priceOrderRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            priceOrderRange.InsertParagraphAfter();
            //скидка
            int discount = 0;
            if (summ > 2000) discount = 5;
            Word.Paragraph discountOrderParagraph = document.Paragraphs.Add();
            Word.Range discountOrderRange = discountOrderParagraph.Range;
            discountOrderRange.Text = $"Скидка: {discount}%";
            discountOrderRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            discountOrderRange.InsertParagraphAfter();
            //пункт выдачи
            Word.Paragraph pickupPointParagraph = document.Paragraphs.Add();
            Word.Range pickupPointRange = pickupPointParagraph.Range;
            pickupPointRange.Text = db.context.Orders.FirstOrDefault(x => x.IdOrder == idOrder).PickupPoint;
            pickupPointRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            pickupPointRange.InsertParagraphAfter();
            //статус заказа
            Word.Paragraph statusParagraph = document.Paragraphs.Add();
            Word.Range statusRange = statusParagraph.Range;
            statusRange.Text = db.context.Orders.FirstOrDefault(x => x.IdOrder == idOrder).StatusOfOrder;
            statusRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            statusRange.InsertParagraphAfter();
            //дата прибытия
            Word.Paragraph dateCommingParagraph = document.Paragraphs.Add();
            Word.Range dateCommingRange = dateCommingParagraph.Range;
            dateCommingRange.Text = db.context.Orders.FirstOrDefault(x => x.IdOrder == idOrder).DateComming;
            dateCommingRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            dateCommingRange.InsertParagraphAfter();
            //получить путь
            string selectedPath = "";
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                selectedPath = folderBrowserDialog.SelectedPath;
                document.SaveAs2($"{selectedPath}\\Order.docx");
            }
            document.Close();
            application.Quit();
        }
    }
}

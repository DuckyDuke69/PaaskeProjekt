using System;
using Microsoft.AspNetCore.Components.Forms;

namespace sheltermini.Client.Pages
{
	public partial class Pedelpage
	{
		private Booking booking = new Booking();
        private EditContext EditContext;
        private List<Booking> Bookinglist = new List<Booking>();

        protected override void OnInitialized()
        {
            EditContext = new EditContext(ProductModel);
        }

        private void HandleValidSubmit()
        {
            Console.WriteLine("HandleValidSubmit Called...");
            ProductList.Add(ProductModel);
        }

        private void HandleInvalidSubmit()
        {
            Console.WriteLine("HandleInvalidSubmit Called...");
        }

        private void ClearProducts()
        {
            ProductList.Clear();
        }

        public string[] Categories = { "None", "A", "B", "C" };
    }
}


using System;
using System.Collections.Generic;

namespace InstantBuyLibrary
{
	public class Cart
	{
		public String totalPrice;
		public String currencyCode;
		public IList<LineItem> lineItems;

		public Cart (String currency)
		{
			this.currencyCode = currency;
		}

		public void addItem(LineItem item) {
			if (lineItems == null) {
				lineItems = new List<LineItem>();
			}
			lineItems.Add(item);
			updateTotal();
		}

		private void updateTotal() {
			Double total = 0.00;
			foreach  (LineItem item in lineItems) {
				total += Convert.ToDouble(item.totalPrice);
			}
			totalPrice = total.ToString();
		}
	}
}


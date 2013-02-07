using System;

namespace InstantBuyLibrary
{
	public class LineItem
	{
		public String description;
		public Int32 quantity;
		public String unitPrice;
		public String totalPrice;
		public String role;
		public Boolean isDigital;
		
		/**
	   * Defines whether the line item is an item, tax or shipping
	   *
	   * If tax/shipping are not defined, then the library assumes it's an item
	   */
		public enum Role {
			TAX, SHIPPING
		}

		public LineItem(String desc, Int32 quantity, String price) {
			this.description = desc;
			this.quantity = quantity;
			this.unitPrice = price;
			this.totalPrice = (quantity * Convert.ToDouble(price)).ToString();
		}

		public LineItem(String desc, String price, Role role) {
			this.description = desc;
			this.totalPrice = price;
			setRole(role);
		}

		public void setRole(Role role) {
			this.role = role.ToString();
		}

		public void setQuantity(Int32 quantity) {
			this.quantity = quantity;
			this.totalPrice = (quantity * Convert.ToDouble(unitPrice)).ToString();
		}

	}
}


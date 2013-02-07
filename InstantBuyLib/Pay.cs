using System;
using System.Collections;

namespace InstantBuyLibrary
{
	public class Pay
	{
		public String estimatedTotalPrice;
		public String currencyCode;
		public String objectId;
		public Int32 expirationMonth;
		public Int32 expirationYear;
		public IList description;
		public Address billingAddress;

		public Pay ()
		{
		}

		public Pay(String etp, String cur) {
			this.estimatedTotalPrice = etp;
			this.currencyCode = cur;
		}
	}
}


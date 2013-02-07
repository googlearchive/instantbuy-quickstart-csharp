using System;

namespace InstantBuyLibrary
{
	public abstract class Jwt
	{
		public String iss;
		public String aud;
		public String typ;
		public long iat;
		public long exp;

		public String getIssuer() {
			return iss;
		}
		
		public void setIssuer(String iss) {
			this.iss = iss;
		}
		
		public long getIat() {
			return iat;
		}
		
		public void setIat(long iat) {
			this.iat = iat;
		}

		public long getExp() {
			return exp;
		}
		
		public void setExp(long exp) {
			this.exp = exp;
		}
		
		public String getType() {
			return typ;
		}
		
		public void setType(String typ) {
			this.typ = typ;
		}
		
		public String getAudience() {
			return aud;
		}
		
		public void setAudience(String aud) {
			this.aud = aud;
		}
	}
}


package model;

public class Users {
	private String uId;
	private String email;
	private String psw;
	private boolean leerkracht;

	public Users(String uId, String email, String psw, boolean leerkracht) {
		super();
		this.uId = uId;
		this.email = email;
		this.psw = psw;
		this.leerkracht = leerkracht;
	}

	public String getuId() {
		return uId;
	}

	public void setuId(String uId) {
		this.uId = uId;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getPsw() {
		return psw;
	}

	public void setPsw(String psw) {
		this.psw = psw;
	}

	public boolean isLeerkracht() {
		return leerkracht;
	}

	public void setLeerkracht(boolean leerkracht) {
		this.leerkracht = leerkracht;
	}

	public Users() {
		// TODO Auto-generated constructor stub
	}

}

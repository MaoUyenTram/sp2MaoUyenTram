package model;

public class QAnswers {
	private int qId;
	private int aId;
	private String uId;
	public int getqId() {
		return qId;
	}
	public void setqId(int qId) {
		this.qId = qId;
	}
	public int getaId() {
		return aId;
	}
	public QAnswers(int qId, int aId, String uId) {
		super();
		this.qId = qId;
		this.aId = aId;
		this.uId = uId;
	}
	public void setaId(int aId) {
		this.aId = aId;
	}
	public String getuId() {
		return uId;
	}
	public void setuId(String uId) {
		this.uId = uId;
	} 
}

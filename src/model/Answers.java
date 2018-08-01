package model;

public class Answers {
	public Answers(int aId, int qId, String answer) {
		super();
		this.aId = aId;
		this.qId = qId;
		this.answer = answer;
	}
	private int aId;
	private int qId;
	private String answer;
	
	public int getaId() {
		return aId;
	}
	public void setaId(int aId) {
		this.aId = aId;
	}
	public int getqId() {
		return qId;
	}
	public void setqId(int qId) {
		this.qId = qId;
	}
	public String getAnswer() {
		return answer;
	}
	public void setAnswer(String answer) {
		this.answer = answer;
	}
	
	
}

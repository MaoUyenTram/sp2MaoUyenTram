package model;

public class Questions {
	private int qId;
	private String question;
	private String method;
	private String Teacher;
	
	public Questions(int qId, String question, String method, String teacher) {
		super();
		this.qId = qId;
		this.question = question;
		this.method = method;
		Teacher = teacher;
	}
	public int getqId() {
		return qId;
	}
	public void setqId(int qId) {
		this.qId = qId;
	}
	public String getQuestion() {
		return question;
	}
	public void setQuestion(String question) {
		this.question = question;
	}
	public String getMethod() {
		return method;
	}
	public void setMethod(String method) {
		this.method = method;
	}
	public String getTeacher() {
		return Teacher;
	}
	public void setTeacher(String teacher) {
		Teacher = teacher;
	}
	
}

package model;

public class Questions  implements java.io.Serializable{
	/**
	 * 
	 */
	private static final long serialVersionUID = -7025124408448443600L;
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
	public Questions(Questions q) {
		this.qId = q.qId;
		this.question = q.question;
		this.method = q.method;
		Teacher = q.Teacher;
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

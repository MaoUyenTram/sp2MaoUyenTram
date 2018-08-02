package controller;

import java.util.ArrayList;

import database.QuestionDAO;
import database.AnswerDAO;
import database.QAnswerDAO;
import javafx.application.Platform;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.Alert;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import javafx.scene.control.Alert.AlertType;
import model.Questions;
import model.Users;
import model.Answers;
import model.Main;
import model.QAnswers;

public class MainController {
	ArrayList<Questions> temp1 = QuestionDAO.getAll();
	ArrayList<Answers> temp2 = null;
	Questions selquestion = null;
	
	@FXML
	private ComboBox<String> questions;
	@FXML
	private ComboBox<String> answers;
	@FXML
	Label label;
	@FXML
	void seeChart() {
		
	}
	
	@FXML
	void submit() throws InterruptedException{ 
		QAnswers a = new QAnswers();
		a.setqId(selquestion.getqId());
		a.setuId(Main.user.getuId());
		for(int i = 0; i <temp2.size();i++){
			if(temp2.get(i).getAnswer().toString().equals(answers.getSelectionModel().getSelectedItem().toString())){
				a.setaId(temp2.get(i).getaId());
			}
		}
		QAnswerDAO.submitAnswer(a);
		alert("dank u ", "Bedankt voor je tijd", AlertType.WARNING);
	}
	@FXML
	private void initialize() {
		for(int i = 0; i <temp1.size();i++){
			String test = temp1.get(i).getQuestion().toString();
			questions.getItems().add(test);
		}
		questions.setOnAction((e) ->{

			for(int i = 0; i <temp1.size();i++){
				if(temp1.get(i).getQuestion().toString().equals(questions.getSelectionModel().getSelectedItem().toString())){
					selquestion = temp1.get(i);
				}
			}
			temp2 = AnswerDAO.getAnswers(selquestion.getqId());
			answers.getItems().clear();
			for(int i = 0; i <temp2.size();i++){
				String test = temp2.get(i).getAnswer().toString();
				answers.getItems().add(test);
			}
			label.setText("Statistic Method:"+ selquestion.getMethod());
		});
	}
	
	public static void alert(String title, String message, AlertType al) throws InterruptedException {
		Alert alert = new Alert(al);
		alert.setHeaderText(null);
		alert.setTitle(title);
		alert.setContentText(message);
		alert.show();
		Thread newThread = new Thread(new Runnable() {
		    @Override
		        public void run() {
		            try {
		                Thread.sleep(1000);
		            } catch (InterruptedException ex) {
		                Thread.currentThread().interrupt();
		            }

		            Platform.runLater(new Runnable() {
		                @Override
		                public void run() {
		                    alert.close();
		                }
		                });
		            }
		    });
		    newThread.start();

	}

}

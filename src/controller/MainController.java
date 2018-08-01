package controller;

import java.util.ArrayList;

import database.QuestionDAO;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.ComboBox;
import model.Questions;

public class MainController {
	
	@FXML
	private ComboBox<String> questions;
	@FXML
	private ComboBox<String> answers;
	
	@FXML
	void seeChart() {
		
	}
	
	@FXML
	void submit(){
		
	}
	
	@FXML
	private void initialize() {
		ArrayList<Questions> temp1 = QuestionDAO.getAll();
		for(int i = 0; i <temp1.size();i++){
			String test = temp1.get(i).getQuestion().toString();
			questions.getItems().add(test);
		}
		questions.setOnAction((e) ->{
		});
	}
}

package controller;

import java.io.IOException;

import database.LoginDAO;
import javafx.application.Platform;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Alert;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.scene.control.Alert.AlertType;
import model.Hash;
import model.Main;
import model.Users;

public class LoginController {
	Users user;
	@FXML
	PasswordField pf_password;
	@FXML
	TextField tf_user;

	@FXML
	void goHome(ActionEvent event) throws InterruptedException{
		Platform.runLater(new Runnable(){
			@Override
			public void run() {
				user = new Users();
				user.setEmail(tf_user.getText());
				user.setPsw(pf_password.getText());
				if (LoginDAO.loginUser(user)) {
						try {
							Main.mainview();
						} catch (IOException e) {
							// TODO Auto-generated catch block
							e.printStackTrace();
						}		
				} else {
						try {
							alert("incorrect email/password. ", "Please check your email/password", AlertType.WARNING);
						} catch (InterruptedException e) {
							// TODO Auto-generated catch block
							e.printStackTrace();
						}
				}
			}
		});		
	}
	

	public static void alert(String title, String message, AlertType al) throws InterruptedException {
		Alert alert = new Alert(al);
		alert.setHeaderText(null);
		alert.setTitle(title);
		alert.setContentText(message);
		alert.show();
		// src https://stackoverflow.com/questions/30755370/javafx-close-alert-box-or-any-dialog-box-programatically
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

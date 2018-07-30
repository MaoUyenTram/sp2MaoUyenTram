package controller;

import database.LoginDAO;
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
	void goHome(ActionEvent event) {

		try {
			user = new Users();
			user.setEmail(tf_user.getText());
			user.setPsw(pf_password.getText());
			if (LoginDAO.loginUser(user)) {
				alert("Success !", "Je bent succesvol ingelogd !", AlertType.INFORMATION);
				Main.mainview();

			} else {
				alert("Username", "Login onmogelijk. ", AlertType.WARNING);
			}
		} catch (NullPointerException e) {
			alert("Error", "Foutief gebruikersnaam / paswoord.", AlertType.WARNING);
			user.setEmail("");
			user.setPsw("");
		} catch (Exception e) {
			alert("FATAL ERROR", "Unknown error, please contact your system administrator and report the bug.",
					AlertType.WARNING);
			e.printStackTrace();
		}
	}

	public static void alert(String title, String message, AlertType al) {
		Alert alert = new Alert(al);
		alert.setHeaderText(null);
		alert.setTitle(title);
		alert.setContentText(message);
		alert.showAndWait();

	}
}

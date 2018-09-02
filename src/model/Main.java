package model;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;

import database.BaseDAO;
import javafx.application.Application;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXMLLoader;
import javafx.scene.Group;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.chart.AreaChart;
import javafx.scene.chart.BarChart;
import javafx.scene.chart.BubbleChart;
import javafx.scene.chart.CategoryAxis;
import javafx.scene.chart.LineChart;
import javafx.scene.chart.NumberAxis;
import javafx.scene.chart.PieChart;
import javafx.scene.chart.XYChart;
import javafx.scene.chart.PieChart.Data;
import javafx.scene.chart.ScatterChart;
import javafx.stage.Modality;
import javafx.stage.Stage;

public class Main extends Application  implements java.io.Serializable{
	/**
	 * 
	 */
	private static final long serialVersionUID = -4059043301321459891L;
	private static Stage primaryStage;
	public static Stage addDialogStage;
	public static Users user;
	
	public Main() {

	}

	@Override
	public void start(Stage primaryStage) throws Exception {
		Main.primaryStage=primaryStage;
		Parent root = FXMLLoader.load(getClass().getResource("/view/login.fxml"));
		Scene scene = new Scene(root);
		scene.setRoot(root);
		primaryStage.setScene(scene);
		primaryStage.show();
		primaryStage.setResizable(false);

	}
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public static void generatechart(ArrayList<Dataholder> q, String method){
		Scene scene= null;
		switch (method){
		case "linechart":
			final CategoryAxis xAxis = new CategoryAxis();
			final NumberAxis yAxis = new NumberAxis();
			final LineChart<String,Number> chart = new LineChart<String,Number>(xAxis,yAxis);
			XYChart.Series series1 = new XYChart.Series();
			for (int e = 0; e < q.size();e++){
				series1.getData().add(new XYChart.Data(q.get(e).getName(),q.get(e).getCount()));
			}
			chart.getData().add(series1);
			scene= new Scene(chart);
		break;
		case "piechart": 
			scene = new Scene(new Group());
			ObservableList<PieChart.Data> pieChartData = FXCollections.observableArrayList();
			for(int e = 0; e < q.size();e++){
				Data ez = new PieChart.Data(q.get(e).getName(),q.get(e).getCount());
				pieChartData.add(ez);
			}
			PieChart chart2 = new PieChart(pieChartData);
			((Group) scene.getRoot()).getChildren().add(chart2);
			break;
	case "areachart":
		final CategoryAxis xAxis2 = new CategoryAxis();
		final NumberAxis yAxis2 = new NumberAxis();
		final AreaChart<String,Number> chart3 = new AreaChart<String,Number>(xAxis2,yAxis2);
		XYChart.Series series2 = new XYChart.Series();
		for (int e = 0; e < q.size();e++){
			series2.getData().add(new XYChart.Data(q.get(e).getName(),q.get(e).getCount()));
		}
		chart3.getData().add(series2);
		scene= new Scene(chart3);
	break;
	case "barchart":
		final CategoryAxis xAxis3 = new CategoryAxis();
		final NumberAxis yAxis3 = new NumberAxis();
		final BarChart<String,Number> chart4 = new BarChart<String,Number>(xAxis3,yAxis3);
		XYChart.Series series3 = new XYChart.Series();
		for (int e = 0; e < q.size();e++){
			series3.getData().add(new XYChart.Data(q.get(e).getName(),q.get(e).getCount()));
		}
		chart4.getData().add(series3);
		scene= new Scene(chart4);
	break;
	/*case "bubblechart":
		final CategoryAxis xAxis4 = new CategoryAxis();
		final NumberAxis yAxis4 = new NumberAxis();
		final BubbleChart<String,Number> chart5 = new BubbleChart<String,Number>(xAxis4,yAxis4);
		XYChart.Series series4 = new XYChart.Series();
		for (int e = 0; e < q.size();e++){
			series4.getData().add(new XYChart.Data(q.get(e).getName(),q.get(e).getCount()));
		}
		chart5.getData().add(series4);
		scene= new Scene(chart5);
	break;*/
	case "scatterchart":
		final CategoryAxis xAxis5 = new CategoryAxis();
		final NumberAxis yAxis5 = new NumberAxis();
		final ScatterChart<String,Number> chart6 = new ScatterChart<String,Number>(xAxis5,yAxis5);
		XYChart.Series series5 = new XYChart.Series();
		for (int e = 0; e < q.size();e++){
			series5.getData().add(new XYChart.Data(q.get(e).getName(),q.get(e).getCount()));
		}
		chart6.getData().add(series5);
		scene= new Scene(chart6);
	break;
		}
		
		
		addDialogStage= new Stage();
		addDialogStage.setResizable(false);
		addDialogStage.initModality(Modality.WINDOW_MODAL);
		addDialogStage.initOwner(primaryStage);
		addDialogStage.setScene(scene);
		addDialogStage.showAndWait();
	}
	
	public static void main(String[] args) {
		BaseDAO b = new BaseDAO();
		launch(args);
	}

	public static void mainview() throws IOException {
		FXMLLoader loader = new FXMLLoader();
		loader.setLocation(Main.class.getResource("/view/main.fxml"));
		Parent root = loader.load();
		Scene scene = new Scene(root);
		primaryStage.setScene(scene);
		primaryStage.show();
		
	}
	
	//src = https://stackoverflow.com/questions/4159802/how-can-i-restart-a-java-application
	// potentiele logout/restart?
	/*public void restartApplication()
	{
	  final String javaBin = System.getProperty("java.home") + File.separator + "bin" + File.separator + "java";
	  final File currentJar = new File(MyClassInTheJar.class.getProtectionDomain().getCodeSource().getLocation().toURI());

	   is it a jar file? 
	  if(!currentJar.getName().endsWith(".jar"))
	    return;

	   Build command: java -jar application.jar 
	  final ArrayList<String> command = new ArrayList<String>();
	  command.add(javaBin);
	  command.add("-jar");
	  command.add(currentJar.getPath());

	  final ProcessBuilder builder = new ProcessBuilder(command);
	  builder.start();
	  System.exit(0);
	}*/



}

<?php

header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");

header("Access-Control-Allow-Methods: POST, GET, OPTIONS, DELETE, PUT");
header("Access-Control-Max-Age: 1000");

header("Access-Control-Allow-Headers: x-requested-with, Content-Type, origin, authorization, accept, client-security-token");


//Creating Array for JSON response
$response = array();
 
// Check if we got the field from the user
if (isset($_GET['info1'])) {
 
    $info1 = $_GET['info1'];
 
    // // Include data base connect class
    // $filepath = realpath (dirname(__FILE__));
	// require_once($filepath."/db_connect.php");

 
    // // Connecting to database 
    // $db = new DB_CONNECT();
    // define('DB_USER',"pabloSotres");
    // define('DB_PASSWORD',"thePassword");
    // define('DB_DATABASE', "datosUruguay");
    // define('DB_SERVER',"localhost");

    $con = mysqli_connect("localhost", "pabloSotres", "thePassword", "datosUruguay");
 
    // Fire SQL query to insert data in weather
    $result = mysqli_query($con, "INSERT INTO sensor3(info1) VALUE('$info1')");
 
    // Check for succesfull execution of query
    if ($result) {
        // successfully inserted 
        $response["success"] = 1;
        $response["message"] = "Sensor 1 successfully created.";
 
        // Show JSON response
        echo json_encode($response);
    } else {
        // Failed to insert data in database
        $response["success"] = 0;
        $response["message"] = "Something has been wrong";
 
        // Show JSON response
        echo json_encode($response);
    }
} else {
    // If required parameter is missing
    $response["success"] = 0;
    $response["message"] = "Parameter(s) are missing. Please check the request";
 
    // Show JSON response
    echo json_encode($response);
}
?>
<?php

header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");

header("Access-Control-Allow-Methods: POST, GET, OPTIONS, DELETE, PUT");
header("Access-Control-Max-Age: 1000");

header("Access-Control-Allow-Headers: x-requested-with, Content-Type, origin, authorization, accept, client-security-token");


//Creating Array for JSON response
$response = array();
 
// Include data base connect class
// $filepath = realpath (dirname(__FILE__));
// require_once($filepath."/db_connect.php");

 // Connecting to database 
// $db = new DB_CONNECT();	

$con = mysqli_connect("localhost", "pabloSotres", "thePassword", "datosUruguay");

 // Fire SQL query to get all data from weather
$result = mysqli_query($con, "SELECT *FROM sensor1");
 
// Check for succesfull execution of query and no results found
if (mysqli_num_rows($result) > 0) {
    
	// Storing the returned array in response
    $response["sensor1"] = array();
 
	// While loop to store all the returned response in variable
    while ($row = mysqli_fetch_array($result)) {
        // temperoary user array
        $sensor1 = array();
        $sensor1["id"] = $row["id"];
        $sensor1["info1"] = $row["info1"];

		// Push all the items 
        array_push($response["sensor1"], $sensor1);
    }
    // On success
    $response["success"] = 1;
 
    // Show JSON response
    echo json_encode($response);
}	
else 
{
    // If no data is found
	$response["success"] = 0;
    $response["message"] = "No data on potenciometro found";
 
    // Show JSON response
    echo json_encode($response);
}
?>
<?php

	echo "connecting to DB".PHP_EOL;
	//code based off examples from mircosoft https://learn.microsoft.com/en-us/azure/azure-sql/database/connect-query-php?view=azuresql

	$serverName = "jp-morgan.database.windows.net"; // update me
    $connectionOptions = array(
        "Database" => "JP-Morgan", // update me
        "Uid" => "JPMorgan", // update me
        "PWD" => "SeniorProject#" // update me
    );
	$connection = sqlsrv_connect($serverName, $connectionOptions);
	if( $connection === false )  
	{  
		echo "Could not connect.\n";  
		die( print_r( sqlsrv_errors(), true));  
	}  
	echo "Connected".PHP_EOL;
	$bodyHtml = NULL;
	$clientName = NULL;
	$companyName = NULL;
	$companyid = NULL;
	$product = NULL;
	$employee = NULL;
	$Cat = NULL;
	
	$tsql= "SELECT SaleID, SaleDate, ClientID, EmpID, ProductID, CatagoryID, Alert, fk_DealID, SaleRevenue  FROM Sale ";
	$tsqlCl= "SELECT ClientID, Email, fName, lName, CompanyID, PhoneNum, EmpID, catagoryID, JoinDate FROM Client ";
	$tsqlCo= "SELECT CompanyID, CompanyName, CompanyRevenue, CatagoryID, employees FROM Company ";
	$getResults= sqlsrv_query($connection, $tsql);
	$getResults1= sqlsrv_query($connection, $tsqlCl);
	$getResults2= sqlsrv_query($connection, $tsqlCo);
	echo ("Reading data from table" . PHP_EOL);
	if ($getResults == FALSE)
		echo (sqlsrv_errors());
	while ($row = sqlsrv_fetch_array($getResults)) {
		if($row['Alert'] == true){
			while(($row1 = sqlsrv_fetch_array($getResults1))){
				//echo ($row1['ClientID'] . " " . $row1['Email'] . " " . $row1['fName'] .$row1['lName'] . " " . $row1['CompanyID'] . PHP_EOL);
				if($row['ClientID'] == $row1['ClientID']){
					$clientName = ($row1['fName'] . " " . $row1['lName']);
					$companyid = ($row1['CompanyID']);
				}
			}
			while(($row2 = sqlsrv_fetch_array($getResults2))){
				//echo ($row2['CompanyID'] . " " . $row2['CompanyName'] . PHP_EOL);
				if($companyid == $row2['CompanyID']){
						$companyName = ($row2['CompanyName']);
				}
			}
			switch($row['ProductID']){
				case '100000':
						$product = ('Personal Checking Account');
						break;
				case '100001':
						$product = ('Personal Savings Account');
						break;
				case '100002':
						$product = ('Secured Credit Card');
						break;
				case '100003':
						$product = ('Travel Credit Card');
						break;
				case '100004':
						$product = ('Gas Credit Card');
						break;
				case '100005':
						$product = ('New Project Loan');
						break;
				case '100006':
						$product = ('Renovation Project Loan');
						break;
				case '100007':
						$product = ('Product Launch Loan');
						break;
				case '100008':
						$product = ('New Store Loan');
						break;
				case '100009':
						$product = ('Money Market Account');
						break;
				case '100010':
						$product = ('Business Credit Card');
						break;
				case '100011':
						$product = ('New Location Loan');
						break;
				case '100012':
						$product = ('Saving Loan');
						break;
			}
			switch($row['EmpID']){
				case '1':
						$employee = ('Test Test');
						break;
				case '2':
						$employee = ('John Smith');
						break;
				case '3':
						$employee = ('Carter Sanders');
						break;
				case '4':
						$employee = ('Admin Admin');
						break;
				case '6':
						$employee = ('Leads potential');
						break;
				case '7':
						$employee = ('Leads potential');
						break;
				case '8':
						$employee = ('Jeff Ligmin');
						break;
				case '9':
						$employee = ('Sam Brown');
						break;
				case '10':
						$employee = ('Jeff Ligmin');
						break;
				case '11':
						$employee = ('Sam Brown');
						break;
				case '12':
						$employee = ('Olivia Lundstrom');
						break;
				case '13':
						$employee = ('Dawson Murphy');
						break;
				case '14':
						$employee = ('Shawn Broyles');
						break;
				case '15':
						$employee = ('Chris Luevano');
						break;						
			}
			switch($row['CatagoryID']){
				case '1':
						$Cat = ('Construction');
						break;
				case '2':
						$Cat = ('Retail');
						break;
				case '3':
						$Cat = ('Professional Services');
						break;
				case '4':
						$Cat = ('Personal Services');
						break;
				case '5':
						$Cat = ('Business to Business');
						break;
				case '6':
						$Cat = ('Restaurants & Quick-Serve Restaurants');
						break;
				case '7':
						$Cat = ('Other');
						break;		
			}
			//echo ($row['SaleID'] . " " . $row['ClientID'] . " " . $row['EmpID'] .$row['ProductID'] . " " . $row['Alert'] . PHP_EOL);
			echo ($clientName . " " . $companyName . " " . $product . " " . $row['SaleRevenue'] . " " . $employee . " " . $Cat . PHP_EOL);

			// The HTML-formatted body of the email
			
			$bodyHtml = ('<h1>Sale Notification</h1>
				<p> This email was sent to notify you of a recent sale, for more info visit 
				<a href="http://jpmorganwebapp.ddns.net/">JPMC</a>.</p><br>' . "" . $employee . " has sold " . $product . " to our client " . $companyName . " (" . $clientName . ") for $" . $row['SaleRevenue'] . " under the category: " .  $Cat . "." . PHP_EOL);
		}
	}
	//code based of tutorial from AWS https://docs.aws.amazon.com/pdfs/ses/latest/dg/ses-dg.pdf#send-using-smtp-programmatically
	// Import PHPMailer classes into the global namespace
	// These must be at the top of your script, not inside a function
	use PHPMailer\PHPMailer\PHPMailer;
	use PHPMailer\PHPMailer\Exception;

	// If necessary, modify the path in the require statement below to refer to the
	// location of your Composer autoload.php file.
	require '/usr/share/nginx/html/phpmailerlibrary/vendor/autoload.php';

	// Replace sender@example.com with your "From" address.
	// This address must be verified with Amazon SES.
	$sender = 'luevano@usf.edu';
	$senderName = 'Notification';

	// Replace recipient@example.com with a "To" address. If your account
	// is still in the sandbox, this address must be verified.
	$recipient = 'cartersanders2023@gmail.com';

	// Replace smtp_username with your Amazon SES SMTP user name.
	$usernameSmtp = 'AKIA4GQC5IRNC46GQR4U';

	// Replace smtp_password with your Amazon SES SMTP password.
	$passwordSmtp = 'BCBnSAEHyxj+J/rU12kcViG0lPUqpRew5OaBOODhAz82';

	// Specify a configuration set. If you do not want to use a configuration
	// set, comment or remove the next line.
	$configurationSet = 'ConfigSet';

	// If you're using Amazon SES in a region other than US West (Oregon),
	// replace email-smtp.us-west-2.amazonaws.com with the Amazon SES SMTP
	// endpoint in the appropriate region.
	$host = 'email-smtp.us-east-2.amazonaws.com';
	$port = 587;

	// The subject line of the email
	$subject = 'Sales Notification';

	// The plain-text body of the email
	$bodyText =  "Sale Notification\r\n This email was sent to notify for a recent sale for more info visit JPMC";

	$mail = new PHPMailer(true);

	try {
		// Specify the SMTP settings.
		$mail->isSMTP(true);
		$mail->setFrom($sender, $senderName);
		$mail->Username   = $usernameSmtp;
		$mail->Password   = $passwordSmtp;
		$mail->Host       = $host;
		$mail->Port       = $port;
		$mail->SMTPAuth   = true;
		$mail->SMTPSecure = 'tls';
		//$mail->addCustomHeader('X-SES-CONFIGURATION-SET', $configurationSet);

		// Specify the message recipients.
		$mail->addAddress($recipient);
		// You can also add CC, BCC, and additional To recipients here.

		// Specify the content of the message.
		$mail->isHTML(true);
		$mail->Subject    = $subject;
		$mail->Body       = $bodyHtml;
		$mail->AltBody    = $bodyText;
		$mail->Send();
		echo "Email sent!" , PHP_EOL;
	} catch (phpmailerException $e) {
		echo "An error occurred. {$e->errorMessage()}", PHP_EOL; //Catch errors from PHPMailer.
	} catch (Exception $e) {
		echo "Email not sent. {$mail->ErrorInfo}", PHP_EOL; //Catch errors from Amazon SES.
	}

	//update query based off example given by microsoft https://learn.microsoft.com/en-us/sql/connect/php/how-to-perform-parameterized-queries?view=sql-server-ver16	
	// Define the Transact-SQL query.  
	//Use question marks as parameter placeholders.  
	$tsql1 = "UPDATE Sale  
			  SET Alert = ?   
			  WHERE Alert = 1";

	/* Initialize $NewAlert */  
	$NewAlert = false;  
	  
	/* Execute the statement with the specified parameter values. */  
	$stmt1 = sqlsrv_query( $connection, $tsql1, array($NewAlert));  
	if( $stmt1 === false )  
	{  
		 echo "Statement 1 could not be executed.\n";  
		 die( print_r( sqlsrv_errors(), true));  
	}  
	  
	/* Free statement resources. */  
	sqlsrv_free_stmt( $stmt1);  
	  
	/* Now verify the updated quantity.  
	Use a question mark as parameter placeholder. */  
	$tsql2 = "SELECT Alert  
			  FROM Sale
			  WHERE Alert = 0";  
	  
	/* Execute the statement with the specified parameter value.  
	Display the returned data if no errors occur. */  
	$stmt2 = sqlsrv_query( $connection, $tsql2, array($NewAlert));  
	if( $stmt2 === false )  
	{  
		 echo "Statement 2 could not be executed.\n";  
		 die( print_r(sqlsrv_errors(), true));  
	}  
	else  
	{  
		 $qty = sqlsrv_fetch_array( $stmt2);  
		 echo "Value of Alert set to false\n";  
	}  
	  
	/* Free statement and connection resources. */  
	sqlsrv_free_stmt( $stmt2);
	//sqlsrv_free_stmt($getResults);	
	sqlsrv_close( $connection);
?>

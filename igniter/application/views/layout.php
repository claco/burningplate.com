<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<title><?php echo config_item('name'); ?>: <?php echo $title; ?></title>
		<link rel="stylesheet" type="text/css" href="http://yui.yahooapis.com/2.6.0/build/reset/reset-min.css">
		<link rel="stylesheet" type="text/css" href="http://yui.yahooapis.com/2.6.0/build/base/base-min.css">
	</head>
	<body>
		<div id="container">
			<div id="header">
				<h1><?php echo config_item('name'); ?></h1>
				<h2><?php echo $title; ?></h2>
			</div>
			<div id="content">
				<?php echo $content_for_layout; ?>
			</div>
			<div id="footer">
                Powered by Code Igniter
			</div>
		</div>
	</body>
</html>
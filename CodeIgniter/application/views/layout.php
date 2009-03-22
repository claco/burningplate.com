<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<title><?php echo config_item('name'); ?>: <?php echo htmlentities($title); ?></title>
		<link rel="stylesheet" type="text/css" href="http://yui.yahooapis.com/2.6.0/build/reset/reset-min.css" />
		<link rel="stylesheet" type="text/css" href="http://yui.yahooapis.com/2.6.0/build/base/base-min.css" />
		<?php $this->load->helper('url'); ?>
	</head>
	<body>
		<div id="container">
			<div id="header">
				<h1><?php echo config_item('name'); ?></h1>
				<h2><?php echo htmlentities($title); ?></h2>
				<ul>
				    <li><?php echo anchor('', 'Home'); ?></li>
				    <li><?php echo anchor('/restaurants', 'Restaurants'); ?></li>
				</ul>
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
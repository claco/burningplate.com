<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<title><?php echo htmlentities(sfConfig::get('app_name')); ?>: <?php echo htmlentities(get_slot('title')) ?></title>
		<link rel="stylesheet" type="text/css" href="http://yui.yahooapis.com/2.6.0/build/reset/reset-min.css" />
		<link rel="stylesheet" type="text/css" href="http://yui.yahooapis.com/2.6.0/build/base/base-min.css" />
	</head>
	<body>
		<div id="container">
			<div id="header">
				<h1><?php echo htmlentities(sfConfig::get('app_name')); ?></h1>
				<h2><?php echo htmlentities(get_slot('title')); ?></h2>
				<ul>
				    <li><?php echo link_to('Home', '@homepage') ?></li>
				    <li><?php echo link_to('Restaurants', '@restaurants') ?></li>
				</ul>
			</div>
			<div id="content">
			
				<?php echo $sf_content ?>
			</div>
			<div id="footer">
                Powered by Symfony
			</div>
		</div>
	</body>
</html>

<?php $restaurant = get_slot('restaurant') ?>
<?php if ($restaurant) { ?>
    <?php $this->name = $restaurant->getName(); ?>
    <?php echo htmlentities($restaurant->getName()) ?>
<?php } ?>
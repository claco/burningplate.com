<?php $restaurant = get_slot('restaurant') ?>
<?php if ($restaurant) { ?>
<div class="restaurant">
    <?php echo link_to(htmlentities($restaurant->getName()), '@restaurant?id='.$restaurant->getId()) ?>
</div>
<?php } ?>
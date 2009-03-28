<?php $restaurants = get_slot('restaurants')?>
<?php if ($restaurants) { ?>
<div class="restaurants">
    <?php foreach($restaurants as $restaurant) { ?>
        <?php slot('restaurant', $restaurant); ?>
        <?php include_partial('global/restaurant') ?>
    <?php } ?>
</div>
<?php } ?>
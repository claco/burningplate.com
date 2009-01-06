<?php if ($restaurant) { ?>
<?php $this->load->helper('url'); ?>
<div class="restaurant">
    <?php echo anchor('restaurants/' . $restaurant->id, htmlentities($restaurant->name)); ?>
</div>
<?php } ?>
<?php if ($restaurant) { ?>
<div class="restaurant">
    <a href="<?php echo Router::url(array('controller'=>'restaurants'), false); ?>/<?php echo $restaurant['Restaurant']['id']; ?>"><?php echo h($restaurant['Restaurant']['name']); ?></a>
</div>
<?php } ?>
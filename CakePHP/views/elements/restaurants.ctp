<?php if ($restaurants && count($restaurants)) { ?>
<div class="restaurants">
<?php foreach($restaurants as $restaurant):
    echo $this->element('restaurant', array('restaurant'=>$restaurant));
endforeach; ?>
</div>
<?php } ?>
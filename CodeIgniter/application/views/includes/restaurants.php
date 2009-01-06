<?php if ($restaurants && count($restaurants)) { ?>
<div class="restaurants">
<?php foreach($restaurants as $restaurant):
    $data['restaurant'] = $restaurant;
    $this->load->view('includes/restaurant', $data);
endforeach; ?>
</div>
<?php } ?>
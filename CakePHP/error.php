<?php

class AppError extends ErrorHandler {
    function error404($params) {
        $this->controller->set('title', 'Resource Not Found'); 
        parent::error404($params);
    }
}

?>
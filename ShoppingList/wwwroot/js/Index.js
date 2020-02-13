
//function deleteItem(form) {
//    $(form).parents('li').remove();
//}


function removeItem(itemId, itemToRemoveId) {
    console.log("test");
    console.log(itemToRemoveId);
    $.ajax({
        url: `/index/remove/${itemId}`,
        type: 'POST',
        success: function (result) {
            $("#" + itemToRemoveId).remove();
        }
    });
}
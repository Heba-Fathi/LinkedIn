
var post = document.getElementById('textEditor');
var postImg = document.getElementById('postBody');

window.onload = function () {
    var btnClear = document.getElementById("btnClear");
    btnClear.addEventListener('click', ClearBtn)
}
post.addEventListener('input', function (e) {
    var val = post.value;
    if (val == null || val.trim() == "") {
        document.querySelector('.mypost-footer_publish-btn').classList.remove('mypost-footer_publishEnable');
        document.querySelector('.mypost-footer_publish-btn').classList.add('mypost-footer_publishDisable');
        //console.log("dakhlt")
    }
    else {
        document.querySelector('.mypost-footer_publish-btn').classList.remove('mypost-footer_publishDisable');
        document.querySelector('.mypost-footer_publish-btn').classList.add('mypost-footer_publishEnable');
        //console.log("dakhlt2")
    }
});
var addHashtag = document.querySelector('.mypost-hashtag');
addHashtag.addEventListener('click', function (e) {
    document.getElementById('textEditor').value += "#";
});

var onAddBtn = function (e) {
    //1.get Data from input fields
    var inputComment = document.querySelector(".inputComment").value;
    document.querySelector('.comment-sec').style.display = 'block';
    document.querySelector('.comment--text').innerHTML += inputComment;
    console.log(inputComment);
    console.log(onAddBtn);

};

document.addEventListener('keypress', function (event) {
    if (event.keyCode === 13 || event.which === 13) {
        onAddBtn(event);
    }
});

document.querySelector('.comment-like').addEventListener('click', function () {
    document.querySelector('.comment-like').classList.toggle('text-primary');
    document.querySelector('.likes-no').classList.toggle('pr-2');
    document.querySelector('.likes-no').classList.toggle('d-inline');

});

document.querySelector('.option-click').addEventListener('click', function () {
    document.querySelector('.comment-options').classList.toggle('d-block');
});

$('#myModal').on('shown.bs.modal', function () {
    $('#myInput').trigger('focus')
})

//reactions popoover  
$('[data-toggle="popover"]').popover({
    trigger: 'manual',
    html: true,
    animation: false,
    viewport: '.container'
}).on('mouseenter', function () {
    var self = this;
    jQuery(this).popover("show");
    jQuery(".popover").on('mouseleave', function () {
        jQuery(self).popover('hide');
    });
}).on('mouseleave', function () {
    var self = this;
    setTimeout(function () {
        if (!jQuery('.popover:hover').length) {
            jQuery(self).popover('hide');
        }
    }, 600);
});
$('body').on('click', '.popover', function (target) {
    // code here
    if (target.target.id !== "") {
        $('.reaction-sign').remove();
        $('.reactions-container').prepend('<i class="' + target.target.className + 'container__Sign reaction-sign"></i>');
    }
});


function readImgURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        document.getElementById("btnImgSelected").style.display = "none";
        var img = document.createElement("img");
        img.id = "imgInserted";
        document.getElementById("imgDiv").appendChild(img);
        reader.onload = function (e) {
            $('#imgInserted')
                .attr('src', e.target.result)
                .width(200)
                .height(250);
        };
        reader.readAsDataURL(input.files[0]);
    }
}

function imgNext() {
    var source = document.querySelector("#imgInserted").outerHTML;
    document.getElementById("postBody").innerHTML = source;
    var x = document.querySelector("#in1");
    var y = document.querySelector("#in2");
    y.files = x.files;
    //console.log(y.files);
}

function ClearBtn() {
    if (confirm("Want to clear?")) {
        $('#post #textEditor').val('');
        var postImg = document.getElementById("postBody");
        postImg.removeChild(postImg.childNodes[0]);
        var imgNext = document.getElementById("imgDiv");
        imgNext.removeChild(imgNext.lastChild);
        console.log(imgNext.lastChild)
        document.getElementById("btnImgSelected").style.display = "block"
    }
}
function HidePostModal() {
    $("#post").modal('hide')
}

function LikeIt(postId) {
    console.log(postId);
    //document.getElementById('like').innerHTML= @Model.Likes.Count;

    $.ajax({
        method: "GET",
        data: { postId: postId },
        url: '/NewsFeed/Like',
        contentType: "application/json",
        dataType: "json",
        success: function (response) {
            console.log("success");
            console.log(response.postId);

        },

    });

}
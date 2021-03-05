$(() => {

    let count = 1

    $("#add-rows").on('click', function () {
        $("#ppl-rows").append(`<div class="row" style="margin-bottom: 10px;">
<tr>
                            <div class="col-md-4">
                                <input class="form-control" type="text" name="people[${count}].firstname" placeholder="First Name" />
                            </div>
                            <div class="col-md-4">
                                <input class="form-control" type="text" name="people[${count}].lastname" placeholder="Last Name" />
                            </div>
                            <div class="col-md-4">
                                <input class="form-control" type="text" name="people[${count}].age" placeholder="Age" />
                            </div></tr>
                        </div>`);
        count++;
    });

  
})

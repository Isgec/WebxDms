var script_xDmStatusID = {
  ACEStatusID_Selected: function (sender, e) {
    var Prefix = sender._element.id.replace('StatusID', '');
    var F_StatusID = $get(sender._element.id);
    var F_StatusID_Display = $get(sender._element.id + '_Display');
    var retval = (!e._value) ? e._item.parentElement.parentElement._value : e._value;
    var p = retval.split('|');
    F_StatusID.value = p[0];
    F_StatusID_Display.innerHTML = e.get_text();
  },
  ACEStatusID_Populated: function (sender, e) {
    var x = sender._completionListElement.childNodes;
    for (var i = 0, h; h = x[i]; i++) {
      h.innerHTML = h.innerText;
    }
    var p = sender.get_element();
    p.style.backgroundImage = 'none';
  }
}
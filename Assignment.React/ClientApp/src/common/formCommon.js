export const FormikToFormdata = (values) => {
    var formData = new FormData();
    Object.keys(values).forEach(key => {
        formData.append(key, values[key])
    });
    return formData;
}
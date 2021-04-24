import React,
{ useState, useEffect } from 'react';
import { Button, Form, FormGroup, Label, Input, InputGroup } from 'reactstrap';
import axios from 'axios';
import { host } from '../../config.js'
import { useFormik } from 'formik';

const AddProduct = (props) => {
    const [categoryItems, setCategoryItem] = useState([]);
    const [product, setProduct] = useState(null);

    const formik = useFormik({
        initialValues: {
            nameProduct: '',
            productDescription: '',
            price: 0,
            idCate: '',
            image: null,
        },
        onSubmit: (values, action) => {
            values = {
                ...values,
                categoryId: Number(values.idCate),
            };

            action.setSubmitting(true);
            console.log(values);

            var formData = new FormData();

            Object.keys(values).forEach(key => {
                formData.append(key, values[key])
            });

            axios.post(host + "/Products", formData)
                .then(response => {
                    setProduct(response.data);
                    console.log(response.data);
                }).catch((error) => {
                    console.log('Post Product Error', error);
                });
            action.setSubmitting(false);
        }
    })

    useEffect(() => {
        if (categoryItems.length === 0) {
            axios.get(host + "/Categories")
                .then(response => {
                    setCategoryItem(response.data);
                }).catch((error) => {
                    console.log('Get Categories Error', error);
                });
        }

        if (product) {
            alert('successful');
        }

    }, [product]);




    return (
        <>
            <Form onSubmit={formik.handleSubmit}>
                <FormGroup>
                    <Label for="nameProduct">Name Product</Label>
                    <Input value={formik.values.nameProduct} onChange={formik.handleChange}
                        name="nameProduct" />
                </FormGroup>
                <FormGroup>
                    <Label for="description">Description</Label>
                    <Input value={formik.values.productDescription} onChange={formik.handleChange}
                        name="description" id="description" />
                </FormGroup>
                <FormGroup>
                    <Label for="price">Price</Label>
                    <Input value={formik.values.price} onChange={formik.handleChange}
                        name="price" id="price" type='number' />
                </FormGroup>

                <InputGroup>
                    <Label for="exampleSelect">Select</Label>
                    <Input type="select" name="idCate" value={formik.values.idCate} onChange={formik.handleChange}>
                        {
                            categoryItems && categoryItems.map(category =>
                                <option value={category.idCate}>{category.nameCate}</option>
                            )}
                    </Input>
                </InputGroup>

                <InputGroup>
                    <input name="image" type="file" onChange={(event) => {
                        formik.setFieldValue("image", event.currentTarget.files[0]);
                    }} />
                </InputGroup>

                <Button disabled={formik.isSubmitting} type='submit' color="success">Submit</Button>
            </Form>
        </>

    );
}

export default AddProduct;
import React, { useState, useEffect } from "react";
import { Button, Form, FormGroup, Label, Input, InputGroup } from "reactstrap";
import { useFormik } from "formik";
import { FormikToFormdata } from "../../common/formCommon.js";
import { PostProducts, PutProducts } from "../../api/productAPI.js";
import { GetCategories } from "../../api/categoryAPI.js";
import { useHistory } from "react-router-dom";
import { useParams } from "react-router-dom";

const AddProduct = (props) => {
  const { id } = useParams();
  const [categoryItems, setCategoryItem] = useState([]);
  const [product, setProduct] = useState(null);
  const history = useHistory();

  const formik = useFormik({
    initialValues: {
      idProduct: "",
      nameProduct: "",
      productDescription: "",
      price: 0,
      idCate: 1,
      image: null,
    },
    onSubmit: async (values, action) => {
      values = {
        ...values,
        categoryId: Number(values.idCate),
      };

      action.setSubmitting(true);

      var formData = FormikToFormdata(values);

      if (id) {
        PutProducts(id, formData, setProduct);
      } else {
        PostProducts(setProduct, formData);
      }

      action.setSubmitting(false);
    },
  });

  useEffect(() => {
    if (categoryItems.length === 0) {
      GetCategories(setCategoryItem);
    }

    if (product) {
      alert("successful");
      history.push("/products");
    }
  }, [product]);

  return (
    <>
      <Form onSubmit={formik.handleSubmit}>
        <FormGroup>
          <Label for="nameProduct">Name Product</Label>
          <Input
            value={formik.values.nameProduct}
            onChange={formik.handleChange}
            name="nameProduct"
          />
        </FormGroup>
        <FormGroup>
          <Label for="productDescription">Description</Label>
          <Input
            value={formik.values.productDescription}
            onChange={formik.handleChange}
            name="productDescription"
            id="productDescription"
          />
        </FormGroup>
        <FormGroup>
          <Label for="price">Price</Label>
          <Input
            value={formik.values.price}
            onChange={formik.handleChange}
            name="price"
            id="price"
            type="number"
          />
        </FormGroup>

        <InputGroup className="my-4 d-flex flex-column">
          <Label for="idCate" className="mr-3">
            Category:{" "}
          </Label>

          <Input
            type="select"
            name="idCate"
            value={formik.values.idCate}
            onChange={formik.handleChange}
          >
            {categoryItems &&
              categoryItems.map((category) => (
                <option value={category.idCate}>{category.nameCate}</option>
              ))}
          </Input>
        </InputGroup>

        <InputGroup className="d-flex flex-column">
          <Label for="Image" className="mr-3">
            Image:{" "}
          </Label>
          <input
            name="Image"
            type="file"
            onChange={(event) => {
              formik.setFieldValue("Image", event.currentTarget.files[0]);
            }}
          />
        </InputGroup>

        <Button
          className="mt-3"
          disabled={formik.isSubmitting}
          type="submit"
          color="success"
        >
          Submit
        </Button>
      </Form>
    </>
  );
};

export default AddProduct;

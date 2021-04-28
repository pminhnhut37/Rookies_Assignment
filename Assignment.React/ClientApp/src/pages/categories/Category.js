import React, { useState, useEffect } from "react";
import { Table, Button } from "reactstrap";

import { TrashFill } from "react-bootstrap-icons";
import { Pen } from "react-bootstrap-icons";
import { GetCategories } from "../../api/categoryAPI.js";

const Category = () => {
  const [categoryItems, setCategory] = useState([]);

  useEffect(() => {
    GetCategories(setCategory);
  }, []);

  return (
    <>
      <h2 className="text-center p-3">Category</h2>
      <Button color="success" className="mb-2 ml-2">
        Create Category
      </Button>
      <Table dark>
        <thead>
          <tr>
            <th>Id Category</th>
            <th>Name Category</th>
          </tr>
        </thead>
        <tbody>
          {categoryItems &&
            categoryItems.map((category) => (
              <tr key={category.idCate}>
                <td>{category.idCate}</td>
                <td>{category.nameCate}</td>
                <td>
                  <Button color="success" className="mr-2">
                    <Pen color="white" size={20} />
                  </Button>
                </td>
                <td>
                  <Button color="danger" className="mr-2">
                    <TrashFill color="white" size={20} />
                  </Button>
                </td>
              </tr>
            ))}
        </tbody>
      </Table>
    </>
  );
};

export default Category;

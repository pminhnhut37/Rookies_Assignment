import React, { useEffect, useState } from 'react';
import { Table, Button } from 'reactstrap';
import { GetUser } from '../../api/userAPI.js';


const User = () => {
  const [user, setUser] = useState([])
  useEffect(() => {
    GetUser()
      .then(response => {
        console.log(response.data);
        setUser(response.data);
      }).catch((error) => {
        console.log('Get Users Error', error);
      });
  }, []);
  return (
    <>
      <h2 className="text-center p-3">User</h2>
      <Table dark>
        <thead>
          <tr>
            <th>User Name</th>
            <th>Email</th>
            <th>Phone Number</th>
          </tr>
        </thead>
        <tbody>
          {
            user && user.map(user =>
              <tr key={user.userName}>
                <td>{user.userName}</td>
                <td>{user.email}</td>
                <td>{user.phoneNumber}</td>
              </tr>
            )
          }
        </tbody>
      </Table>
    </>
  )
}

export default User;
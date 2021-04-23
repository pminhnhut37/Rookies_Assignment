import React, { useState } from 'react';
import {
    Collapse,
    Navbar,
    NavbarToggler,
    Nav,
    NavItem,
    NavLink,
    Button
} from 'reactstrap';
import { Link } from 'react-router-dom';

const Navigation = (props) => {
    const [isOpen, setIsOpen] = useState(false);

    const toggle = () => setIsOpen(!isOpen);

    return (
        <div>
            <Navbar color="light" light expand="md">
                <img width="150px" src="./logo-nash.png"></img>
                <NavbarToggler onClick={toggle} />
                <Collapse isOpen={isOpen} navbar>
                    <Nav className="mr-auto" navbar>
                        <NavItem>
                            <NavLink><Link className="text-decoration-none" to="/categories">
                                    Category
                            </Link>
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink><Link className="text-decoration-none" to="/products">
                                Products
                            </Link></NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink><Link className="text-decoration-none" to="/users">
                                Users
                            </Link></NavLink>
                        </NavItem>
                    </Nav>
                </Collapse>
                <Button color="danger" className="float-right">Sign out</Button>
            </Navbar>
        </div>
    );
}

export default Navigation;
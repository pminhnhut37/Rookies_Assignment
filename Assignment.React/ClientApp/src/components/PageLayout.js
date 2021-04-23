import React from 'react';
import { Container, Col } from 'reactstrap';

export default function PageLayout({ header, content }) {

    return (
        <Container fluid={true}>
            <div className='p-3' style={{ backgroundColor: "#F35444" }}>{header}</div>
            <Col className="p-4" style={{ backgroundColor: "#FAE9E7" }} xs={12}>
                <div className="bg-white h-100 rounded p-3">{content}</div>
            </Col>
        </Container>
    );

} 
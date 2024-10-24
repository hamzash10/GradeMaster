import React, { useState } from 'react';
import { login } from '../../services/ApiCalls/auth';
import { useNavigate } from 'react-router-dom';

import { Modal, Button, Form, Container } from 'react-bootstrap';
import { Link } from 'react-router-dom';

const Login = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        const response = await login({ email, password });
        if (response.status === 200) {
            console.log("Frontend: Login successful!");
            navigate('/');
        } else {
            console.error("Login failed.");
        }
    };

    return (
        <Container>
            <Modal show centered backdrop={false} keyboard={false}>

                <Modal.Header className="d-flex justify-content-center">
                    <Modal.Title className="text-center mb-4">Login</Modal.Title>
                </Modal.Header>

                <Modal.Body>
                    <Form onSubmit={handleSubmit}>
                        <Form.Group className="mb-3" controlId="formEmail">
                            <Form.Label>Email</Form.Label>
                            <Form.Control
                                type="email"
                                placeholder="Enter your email"
                                value={email}
                                onChange={(e) => setEmail(e.target.value)}
                                required
                            />
                        </Form.Group>
                        <Form.Group className="mb-3" controlId="formPassword">
                            <Form.Label>Password</Form.Label>
                            <Form.Control
                                type="password"
                                placeholder="Enter your password"
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                                required
                            />
                        </Form.Group>
                    </Form>
                </Modal.Body>

                <Modal.Footer className="d-flex flex-column justify-content-center">
                    <Button type="submit" className="btn  btn-primary btn-block w-100">
                        <h5>Login</h5>
                    </Button>
                    <p className="mt-2">
                        Don't have an account? <Link to="/register">Register</Link>
                    </p>
                </Modal.Footer>
            </Modal>

        </Container>
    );
};

export default Login;

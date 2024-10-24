import { useState } from "react";
import { register } from "../../services/ApiCalls/auth";
import { useNavigate, Link } from 'react-router-dom';

import { Modal, Button, Form, Container } from 'react-bootstrap';

const Register = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await register({ email, password, firstName, lastName, phoneNumber });
            if (response.status === 200) {
                console.log("Frontend: registered successfuly")
                navigate('/');
            }
        } catch (error) {
            // Handle errors here
            console.error('Login failed:', error.response?.data || error.message);
        }
    };

    return (
        <Container>
            <Modal show centered backdrop={false} keyboard={false}>
                <Modal.Header className="d-flex justify-content-center">
                    <Modal.Title className="text-center">Register</Modal.Title>
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
                        <Form.Group className="mb-3" controlId="formFirstName">
                            <Form.Label>First Name</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter your first name"
                                value={firstName}
                                onChange={(e) => setFirstName(e.target.value)}
                                required
                            />
                        </Form.Group>
                        <Form.Group className="mb-3" controlId="formLastName">
                            <Form.Label>Last Name</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter your last name"
                                value={lastName}
                                onChange={(e) => setLastName(e.target.value)}
                                required
                            />
                        </Form.Group>
                        <Form.Group className="mb-3" controlId="formPhoneNumber">
                            <Form.Label>Phone Number</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter your phone number"
                                value={phoneNumber}
                                onChange={(e) => setPhoneNumber(e.target.value)}
                                required
                            />
                        </Form.Group>
                    </Form>
                </Modal.Body>
                <Modal.Footer className="d-flex flex-column justify-content-center">
                    <Button type="submit" onClick={handleSubmit} className="btn btn-primary btn-block w-100">
                        <h5>Register</h5>
                    </Button>
                    <p className="mt-2">
                        already registered? <Link to="/login">Login</Link>
                    </p>
                </Modal.Footer>
            </Modal>
        </Container>
    );
};

export default Register;
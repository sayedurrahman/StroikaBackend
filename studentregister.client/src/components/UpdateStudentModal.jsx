import React from 'react';
import { Modal, Button, Form, Row, Col } from 'react-bootstrap';
import { useSelector } from 'react-redux';
import useStudentData from '../hooks/useStudentData'; 

const UpdateStudentModal = ({ show, handleClose, studentData, handleSave }) => {
    const userRole = useSelector((state) => state.userRole.role);
    const nationalities = useSelector((state) => state.nationalities.nationalities);
    const {
        student,
        handleChange,
        handleFamilyMemberChange,
        addFamilyMember,
        deleteFamilyMember,
    } = useStudentData(studentData);

    // Handle form submission
    const handleSubmit = (e) => {
        e.preventDefault();
        handleSave(student);
    };

    return (
        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Update Student Information</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form onSubmit={handleSubmit}>
                    {/* Main Student Information */}
                    <Row className="mb-3">
                        <Col>
                            <Form.Group>
                                <Form.Label>First Name</Form.Label>
                                <Form.Control
                                    type="text"
                                    name="firstName"
                                    value={student.firstName}
                                    onChange={handleChange}
                                    disabled={userRole === 'Admin'}
                                />
                            </Form.Group>
                        </Col>
                        <Col>
                            <Form.Group>
                                <Form.Label>Last Name</Form.Label>
                                <Form.Control
                                    type="text"
                                    name="lastName"
                                    value={student.lastName}
                                    onChange={handleChange}
                                    disabled={userRole === 'Admin'}
                                />
                            </Form.Group>
                        </Col>
                    </Row>
                    <Row className="mb-3">
                        <Col>
                            <Form.Group>
                                <Form.Label>Date of Birth</Form.Label>
                                <Form.Control
                                    type="date"
                                    name="dob"
                                    value={student.dob}
                                    onChange={handleChange}
                                    disabled={userRole === 'Admin'}
                                />
                            </Form.Group>
                        </Col>
                        <Col>
                            <Form.Group className="mb-3">
                                <Form.Label>Nationality</Form.Label>
                                <Form.Select name="nationalityId" value={student.nationalityId} onChange={handleChange} disabled={userRole === 'Admin'}>
                                    <option key='0' value='0'>Select a nationality</option>
                                    {nationalities.map((nationality) =>
                                        <option key={nationality.id} value={nationality.id} >{nationality.name}</option>
                                    )}
                                </Form.Select>
                            </Form.Group>
                        </Col>
                    </Row>

                    {/* Family Members Section */}
                    <h5>Family Members</h5>
                    {student.familyMembers && student.familyMembers.length > 0 &&
                        student.familyMembers.map((member, index) => (
                            <div key={index} className="mb-3 border p-3">
                                <Row>
                                    <Col>
                                        <Form.Group>
                                            <Form.Label>First Name</Form.Label>
                                            <Form.Control
                                                type="text"
                                                name="firstName"
                                                value={member.firstName}
                                                onChange={(e) => handleFamilyMemberChange(index, e)}
                                            />
                                        </Form.Group>
                                    </Col>
                                    <Col>
                                        <Form.Group>
                                            <Form.Label>Last Name</Form.Label>
                                            <Form.Control
                                                type="text"
                                                name="lastName"
                                                value={member.lastName}
                                                onChange={(e) => handleFamilyMemberChange(index, e)}
                                            />
                                        </Form.Group>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col>
                                        <Form.Group>
                                            <Form.Label>Date of Birth</Form.Label>
                                            <Form.Control
                                                type="date"
                                                name="dob"
                                                value={member.dob}
                                                onChange={(e) => handleFamilyMemberChange(index, e)}
                                            />
                                        </Form.Group>
                                    </Col>
                                    <Col>
                                        <Form.Group>
                                            <Form.Label>Nationality ID</Form.Label>
                                            <Form.Select name="nationalityId" value={member.nationalityId} onChange={(e) => handleFamilyMemberChange(index, e)}>
                                                <option key='0' value='0'>Select a nationality</option>
                                                {nationalities.map((nationality) =>
                                                    <option key={nationality.id} value={nationality.id} >{nationality.name}</option>
                                                )}
                                            </Form.Select>
                                        </Form.Group>
                                    </Col>
                                    <Col>
                                        <Form.Group>
                                            <Form.Label>Relation ID</Form.Label>
                                            <Form.Select name="relationId" value={member.relationId} onChange={(e) => handleFamilyMemberChange(index, e)}>
                                                <option key='0' value='0'>Select a Relation</option>
                                                <option key='1' value='1' >Parent</option>
                                                <option key='2' value='2' >Sibling</option>
                                                <option key='3' value='3' >Spouse</option>
                                            </Form.Select>
                                        </Form.Group>
                                    </Col>
                                </Row>
                                <Button
                                    variant="danger"
                                    className="mt-2"
                                    onClick={() => deleteFamilyMember(index)}
                                >
                                    Delete Family Member
                                </Button>
                            </div>
                        ))}
                    <Button variant="primary" onClick={addFamilyMember} className="mb-3">
                        Add Family Member
                    </Button>

                    {/* Modal Footer */}
                    <Modal.Footer>
                        <Button variant="secondary" onClick={handleClose}>
                            Close
                        </Button>
                        <Button variant="primary" type="submit">
                            Save Changes
                        </Button>
                    </Modal.Footer>
                </Form>
            </Modal.Body>
        </Modal>
    );
};

export default UpdateStudentModal;

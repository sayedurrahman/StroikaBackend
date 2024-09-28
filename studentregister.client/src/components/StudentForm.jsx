import React, { useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';

const StudentForm = (props) => {
    const nationalities = useSelector((state) => state.nationalities.nationalities);
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [dateOfBirth, setDob] = useState(new Date());
    const [nationalityId, setNationalityId] = useState(0);
    const dispatch = useDispatch();
    const student = props.studentData;
    //const role = useSelector((state) => state.userRole.role);
    
    const handleChange = (event) => {
        const selectedNationality = event.target.value;
        dispatch(setNationalityId(selectedNationality));
    };

    // Load student data when it becomes available
    useEffect(() => {
        if (student) {
            setFirstName(student.firstName || '');
            setLastName(student.lastName || '');
            setDob(student.dateOfBirth || new Date());
        }
    }, [student]);

    // Handle form submission
    const handleSubmit = (e) => {
        e.preventDefault(); // Prevent page refresh

        // Create an object with the form data
        const formData = {
            firstName,
            lastName,
            dateOfBirth
        };

        //console.log(formData);

        // Call the onSubmit prop function with the form data
        //if (onSubmit) {
        //    onSubmit(formData);
        //}
    };

    return (
        <form onSubmit={handleSubmit}>
            <label>
                First name:
                <input
                    value={firstName}
                    onChange={e => setFirstName(e.target.value)}
                />
            </label>
            <br />
            <label>
                Last name:
                <input
                    value={lastName}
                    onChange={e => setLastName(e.target.value)}
                />
            </label>
            <br />
            <label>
                Date Of Birth:
                <input
                    type="datetime-local"
                    value={dateOfBirth}
                    onChange={e => setDob(e.target.value)}
                />
            </label>
            <br />
            <label>
                Nationality:
                <select value={nationalityId} onChange={handleChange}>
                    {nationalities.map((nationality) =>
                        <option key={nationality.Id} value={nationality.Id}>{nationality.name} {nationality.country}</option>
                    )}
                </select>
            </label>


            
            <br />
            <button type="submit">Submit</button>
        </form>
    );
}

export default StudentForm;
import axios from 'axios';
const baseUrl = '/core/api/Students';

export const updateStudentDetails = async (id, studentData) => {
    try {
        const response = await axios.put(`${baseUrl}/${id}`, studentData);
        return response.data;
    } catch (error) {
        console.error('Error updating student details:', error);
        throw error;
    }
};

export const getStudentNationality = async (id) => {
    try {
        const response = await axios.get(`${baseUrl}/${id}/Nationality`);
        return response.data;
    } catch (error) {
        console.error('Error fetching student nationality:', error);
        throw error;
    }
};

export const updateStudentNationality = async (id, nationalityId) => {
    try {
        const response = await axios.put(`${baseUrl}/${id}/Nationality/${nationalityId}`);
        return response.data;
    } catch (error) {
        console.error('Error updating student nationality:', error);
        throw error;
    }
};

export const getStudentFamilyMembers = async (id) => {
    try {
        const response = await axios.get(`${baseUrl}/${id}/FamilyMembers`);
        return response.data;
    } catch (error) {
        console.error('Error fetching family members:', error);
        throw error;
    }
};

export const createFamilyMember = async (id, familyMemberData) => {
    try {
        const response = await axios.post(`${baseUrl}/${id}/FamilyMembers`, familyMemberData);
        return response.data;
    } catch (error) {
        console.error('Error creating family member:', error);
        throw error;
    }
};

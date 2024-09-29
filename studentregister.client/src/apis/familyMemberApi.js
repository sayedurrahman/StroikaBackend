import axios from 'axios';
const familyMemberBaseUrl = 'https://localhost:7237/api/FamilyMembers';

export const updateFamilyMember = async (id, familyMemberData) => {
    try {
        const response = await axios.put(`${familyMemberBaseUrl}/${id}`, familyMemberData);
        return response.data;
    } catch (error) {
        console.error('Error updating family member:', error);
        throw error;
    }
};

export const deleteFamilyMember = async (id) => {
    try {
        await axios.delete(`${familyMemberBaseUrl}/${id}`);
    } catch (error) {
        console.error('Error deleting family member:', error);
        throw error;
    }
};

export const getFamilyMemberNationality = async (id, nationalityId) => {
    try {
        const response = await axios.get(`${familyMemberBaseUrl}/${id}/Nationality/${nationalityId}`);
        return response.data;
    } catch (error) {
        console.error('Error fetching family member nationality:', error);
        throw error;
    }
};

export const updateFamilyMemberNationality = async (id, nationalityId) => {
    try {
        const response = await axios.put(`${familyMemberBaseUrl}/${id}/Nationality/${nationalityId}`);
        return response.data;
    } catch (error) {
        console.error('Error updating family member nationality:', error);
        throw error;
    }
};

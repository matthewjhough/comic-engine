import { connect } from 'react-redux';
import { ComicSearchForm } from './ComicSearchForm';
import {
  updateTitleInput,
  updateIssueNumberInput,
  updateResultsFromForm
} from './comicSearchFormActions';
import { toggleLoading } from '../ComicResults/comicResultsActions';

const mapStateToProps = ({ comicSearchForm }) => ({
  ...comicSearchForm
});

const mapDispatchToProps = dispatch => ({
  updateTitleInput: title => dispatch(updateTitleInput(title)),
  updateIssueNumberInput: issueNumber =>
    dispatch(updateIssueNumberInput(issueNumber)),
  updateResultsFromForm: dispatch(updateResultsFromForm),
  toggleComicSearchLoadingTrue: () => dispatch(toggleLoading(true))
});

export const ComicSearchFormContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(ComicSearchForm);

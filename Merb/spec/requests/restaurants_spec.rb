require File.join(File.dirname(__FILE__), '..', 'spec_helper.rb')

describe "/restaurants" do
  before(:each) do
    @response = request("/restaurants")
  end
end